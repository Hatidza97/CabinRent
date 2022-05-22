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
        public bool Delete(int id)
        {
            var entity = context.Korisniks.Find(id);
            if (entity != null)
            {
                context.Korisniks.Remove(entity);
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
            entity.Email = request.Email;
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Sifra);
            context.Korisniks.Add(entity);

            context.SaveChanges();
            return _mapper.Map<Model.Korisnik>(entity);
        }
        public static string GenerateSalt()
        {
            var buff = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public static string GenerateHash(string salt, string password)
        {
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


        public async Task<Model.Korisnik> Login(KorisniciLoginRequest request)
        {
            var korisnik = context.Korisniks.Include(x => x.KorisnikUloges).FirstOrDefault(x => x.KorisnickoIme == request.Username);

            if (korisnik == null)
            {
                throw new UserException("Pogrešan username ili password");
            }
            var hash = GenerateHash(korisnik.LozinkaSalt, request.Password);
            if (hash != korisnik.LozinkaHash)
            {
                throw new UserException("Pogrešan username ili password");

            }
            return _mapper.Map<Model.Korisnik>(korisnik);

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
