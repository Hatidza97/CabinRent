using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using AutoMapper;
using CabinRent.Services.Database;
using CabinRent.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CabinRent.Model.SearchObjects;

namespace CabinRent.Services
{
    public class KorisniciService : IKorisniciService
    {
        protected readonly IMapper _mapper;
        public eRentContext context { get; set; }
        public KorisniciService(eRentContext Context, IMapper mapper)
        {
            context = Context;
            _mapper = mapper;
        }
       
        public Model.Korisnik GetById(int id)
        {
            var entity = context.Korisniks.Find(id);
            return _mapper.Map<Model.Korisnik>(entity);
        }
        //public bool Delete(int id)
        //{
        //    var entity = context.Korisniks.Find(id);
        //    if (entity != null)
        //    {
        //        context.Korisniks.Remove(entity);
        //        context.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}
        //public bool Delete(int id)
        //{
        //    var korisnik = context.Korisniks.Find(id);
        //    if (korisnik != null)
        //    {
        //        // Find and delete related records from KorisnikUloge table
        //        var relatedUloge = context.KorisnikUloges.Where(u => u.KorisnikId == id);
        //        context.KorisnikUloges.RemoveRange(relatedUloge);

        //        var relatedObjects = context.Objekats.Where(u => u.KorisnikId == id);
        //        context.Objekats.RemoveRange(relatedObjects);

        //        // Delete the Korisnik record
        //        context.Korisniks.Remove(korisnik);

        //        // Save changes
        //        context.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}

        public bool Delete(int id)
        {
            var korisnik = context.Korisniks.Find(id);
            if (korisnik != null)
            {
                // Find and delete related records from KorisnikUloge table
                var relatedUloge = context.KorisnikUloges.Where(u => u.KorisnikId == id).ToList();
                context.KorisnikUloges.RemoveRange(relatedUloge);

                // Find related Objekats and their associated TipObjektaSlike
                var relatedObjects = context.Objekats.Where(u => u.KorisnikId == id).ToList();
                foreach (var objekat in relatedObjects)
                {
                    var relatedSlike = context.TipObjektaSllikes.Where(s => s.ObjekatId == objekat.ObjekatId).ToList();
                    context.TipObjektaSllikes.RemoveRange(relatedSlike);
                }

                // Remove related Objekats
                context.Objekats.RemoveRange(relatedObjects);

                // Delete the Korisnik record
                context.Korisniks.Remove(korisnik);

                // Save changes
                context.SaveChanges();
                return true;
            }
            return false;
        }



        [HttpPost]
        public Model.Korisnik Insert(KorisniciInsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnik>(request);
            entity.Ime = request.Ime;
            entity.Prezime = request.Prezime;
            entity.Email = request.Email;
            entity.Telefon = request.Telefon;
            entity.KorisnickoIme = request.KorisnickoIme;
            entity.Slika = request.Slika;
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Sifra);
            context.Korisniks.Add(entity);

            context.SaveChanges();
            return _mapper.Map<Model.Korisnik>(entity);
        }
        public static string GenerateSalt()
        {
            //var buff = new byte[16];
            //(new RNGCryptoServiceProvider()).GetBytes(buff);
            //return Convert.ToBase64String(buff);

            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            //byte[] src = Convert.FromBase64String(salt);
            //byte[] bytes = Encoding.Unicode.GetBytes(password);
            //byte[] dst = new byte[src.Length + bytes.Length];

            //System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            //System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            //HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            //byte[] inArray = algorithm.ComputeHash(dst);
            //return Convert.ToBase64String(inArray);
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);

        }
        public List<Model.Korisnik> Get(KorisniciSearchRequest request)
        {
            var query = context.Korisniks.Include(x => x.Objekats)
                .Include(x => x.KorisnikUloges)
                .AsQueryable();
            if (request.KorisnikID != null)
            {
                query = query.Where(x => x.KorisnikId == request.KorisnikID);
            }
            if (!string.IsNullOrWhiteSpace(request.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }
            if (!string.IsNullOrWhiteSpace(request.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }
            if (!string.IsNullOrWhiteSpace(request.Telefon))
            {
                query = query.Where(x => x.Telefon.Contains(request.Telefon));
            }
            if (!string.IsNullOrWhiteSpace(request.Username))
            {
                query = query.Where(x => x.KorisnickoIme == request.Username);
            }
            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(x => x.Email.StartsWith(request.Email));
            }
            if (request.Slika != null)
            {
                query = query.Where(x => x.Slika.Any());
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Korisnik>>(list);
        }
        public List<Model.Korisnik> GetRegistracija(KorisniciSearchRequest request)
        {
            var query = context.Korisniks.Include(x => x.Objekats)
                .Include(x => x.KorisnikUloges)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Username))
            {
                query = query.Where(x => x.KorisnickoIme == request.Username);
            }


            var list = query.ToList();
            return _mapper.Map<List<Model.Korisnik>>(list);
        }
        public Model.Korisnik Update(int id, KorisniciUpdateRequest request)
        {
            var entity = context.Korisniks.Find(id);

            context.Korisniks.Attach(entity);
            context.Korisniks.Update(entity);

            _mapper.Map(request, entity);
            context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }


        public Model.Korisnik Login(string username,string password)
        {
            var entity = context.Korisniks.Include("KorisnikUloges.Uloga")
                .FirstOrDefault(x => x.KorisnickoIme == username);
            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if (hash != entity.LozinkaHash)
            {
                return null;
            }

            return _mapper.Map<Model.Korisnik>(entity);

        }
        public ActionResult<Model.Korisnik> SignUp(KorisniciUpdateRequest request)
        {
            var entity = _mapper.Map<Korisnik>(request);
            //entity.ti = 2;

            if (request.Password != request.ConfirmPassword)
            {
                throw new Exception("Password i potvrda passworda nisu iste");
            }
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            entity.KorisnickoIme = request.Username;
            context.Korisniks.Add(entity);
            context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }

    }
}
