part of 'user.dart';

User _$UserFromJson (Map<String, dynamic> json) => User()
  ..korisnikId= json['korisnikId'] as int?
  ..ime = json['ime'] as String?
  ..prezime = json['prezime'] as String?
  ..slika = json['slika'] as String?
  ..telefon = json['telefon'] as String?
  ..korisnickoIme = json['korisnickoIme'] as String?;

  Map<String, dynamic> _$UserToJson(User instance) => <String, dynamic>{
      'korisnikId': instance.korisnikId,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'slika': instance.slika,
      'telefon': instance.telefon,
      'korisnickoIme': instance.korisnickoIme,
    };