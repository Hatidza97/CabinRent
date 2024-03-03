// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'rezervacija.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Rezervacija _$RezervacijaFromJson(Map<String, dynamic> json) {
  return Rezervacija(
    json['rezervacijaId'] as int,
    json['datumPrijave'] as String,
    json['datumOdjave'] as String,
    json['brojOdraslih'] as int,
    json['brojDjece'] as int,
    json['otkazano'] as bool,
    json['objekatId'] as int
  );
}

Map<String, dynamic> _$RezervacijaToJson(Rezervacija instance) => <String, dynamic>{
      'rezervacijaId': instance.rezervacijaId,
      'datumPrijave': instance.datumPrijave,
      'datumOdjave': instance.datumOdjave,
      'brojOdraslih': instance.brojOdraslih,
      'brojDjece': instance.brojDjece,
      'otkazano': instance.otkazano,
      'objekatId': instance.objekatId
    };
