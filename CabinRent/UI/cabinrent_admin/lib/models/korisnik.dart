import 'package:json_annotation/json_annotation.dart';

part 'korisnik.g.dart';

@JsonSerializable()
class Korisnik{
int? korisnikId;
String? ime;
String? prezime;
String? email;
String? telefon;
String? korisnickoIme;
String? slika;
Korisnik(this.korisnikId,this.ime,this.prezime,this.email,this.telefon,this.korisnickoIme,this.slika);

factory Korisnik.fromJson(Map<String,dynamic> json)=>_$KorisnikFromJson(json);

Map<String,dynamic> toJson()=>_$KorisnikToJson(this);
}
