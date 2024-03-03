// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'korisnik.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Korisnik _$KorisnikFromJson(Map<String, dynamic> json) {
  return Korisnik(
    json['korisnikId'] as int,
    json['ime'] as String,
    json['prezime'] as String,
    json['email'] as String,
    json['telefon'] as String,
    json['korisnickoIme'] as String,
    json['slika'] as String
  );
}

Map<String, dynamic> _$KorisnikToJson(Korisnik instance) => <String, dynamic>{
      'korisnikId': instance.korisnikId,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'email': instance.email,
      'telefon': instance.telefon,
      'korisnickoIme': instance.korisnickoIme,
      'slika': instance.slika
    };
