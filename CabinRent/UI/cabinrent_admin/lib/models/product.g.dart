// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'product.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Objekat _$ObjekatFromJson(Map<String, dynamic> json) {
  return Objekat(
    json['objekatId'] as int,
    json['naziv'] as String,
    json['povrsina'] as String,
    json['brojMjestaDjeca'] as int,
    json['brojMjestaOdrasli'] as int,
    json['brojMjestaUkupno'] as int,
    json['opis'] as String,
    json['rezervisan'] as bool,
    json['gradId'] as int,
    json['cijena'] as int,
    json['tipObjektaId'] as int,
    json['korisnikId'] as int,
  );
}

Map<String, dynamic> _$ObjekatToJson(Objekat instance) => <String, dynamic>{
      'objekatId': instance.objekatId,
      'naziv': instance.naziv,
      'povrsina': instance.povrsina,
      'brojMjestaDjeca': instance.brojMjestaDjeca,
      'brojMjestaOdrasli': instance.brojMjestaOdrasli,
      'brojMjestaUkupno': instance.brojMjestaUkupno,
      'opis': instance.opis,
      'rezervisan':instance.rezervisan,
      'gradId':instance.gradId,
      'cijena':instance.cijena,
      'tipObjektaId':instance.tipObjektaId,
      'korisnikId':instance.korisnikId,
    };
