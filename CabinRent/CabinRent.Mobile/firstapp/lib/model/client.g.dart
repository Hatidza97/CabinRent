part of 'client.dart';
Klijent _$KlijentFromJson(Map<String, dynamic> json) => Klijent()
  ..klijentId = json['klijentId'] as int?
  ..ime = json['ime'] as String?
  ..prezime = json['prezime'] as String?
  ..korisnickoIme = json['korisnickoIme'] as String?
  ..telefon = json['telefon'] as String?
  ..slika = json['slika'] as String?;

Map<String, dynamic> _$KlijentToJson(Klijent instance) => <String, dynamic>{
      'klijentId': instance.klijentId,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'korisnickoIme': instance.korisnickoIme,
      'telefon': instance.telefon,
      'slika': instance.slika,
    };
