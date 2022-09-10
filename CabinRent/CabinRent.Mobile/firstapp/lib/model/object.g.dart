// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'object.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Objekat _$ObjekatFromJson(Map<String, dynamic> json) => Objekat()
  ..objekatId = json['objekatId'] as int?
  ..naziv = json['naziv'] as String?
  ..povrsina = json['povrsina'] as String?
  ..opis = json['opis'] as String?
  ..brojMjestaDjeca = json['brojMjestaDjeca'] as int?
  ..brojMjestaOdrasli = json['brojMjestaOdrasli'] as int?
  ..gradId=json['gradId'] as int?
  ..tipObjektaId=json['tipObjektaId'] as int?
  ..grad= json['grad'] == null
          ? null
          : Grad.fromJson(json['grad'] as Map<String, dynamic>)
  ..tipObjekta=json['tipObjekta']==null?null:TipObjekta.fromJson(json['tipObjekta']as Map<String,dynamic>)
  ..korisnikId=json['korisnikId'] as int?
  ..korisnik=json['korisnik']==null?null:User.fromJson(json['korisnik'] as Map<String,dynamic>);
          

Map<String, dynamic> _$ObjekatToJson(Objekat instance) => <String, dynamic>{
      'objekatId': instance.objekatId,
      'naziv': instance.naziv,
      'povrsina': instance.povrsina,
      'opis': instance.opis,
      'brojMjestaDjeca': instance.brojMjestaDjeca,
      'brojMjestaOdrasli': instance.brojMjestaOdrasli,
      'korisnikId':instance.korisnikId,
      'korisnik':instance.korisnik,
      'tipObjektaId':instance.tipObjektaId,
      'tipObjekta':instance.tipObjekta,
      'gradId':instance.gradId,
      'grad':instance.grad
    };
