// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'klijent.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Klijent _$KlijentFromJson(Map<String, dynamic> json) {
  return Klijent(
    json['klijentId'] as int,
    json['ime'] as String,
    json['prezime'] as String,
    json['email'] as String,
    json['telefon'] as String,
    json['korisnickoIme'] as String,
    json['slika'] as String,
    json['gradId'] as int,
  );
}

Map<String, dynamic> _$KlijentToJson(Klijent instance) => <String, dynamic>{
      'klijentId': instance.klijentId,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'email': instance.email,
      'telefon': instance.telefon,
      'korisnickoIme': instance.korisnickoIme,
      'slika': instance.slika,
      'gradId': instance.gradId
    };
