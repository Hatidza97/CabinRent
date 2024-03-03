// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'pictures.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TipObjektaSllike _$TipObjektaSllikeFromJson(Map<String, dynamic> json) {
  return TipObjektaSllike(
    json['tipObjektaSlikeId'] as int,
    json['objekatId'] as int,
    json['imageData'] as String,
  );
}

Map<String, dynamic> _$TipObjektaSllikeToJson(TipObjektaSllike instance) => <String, dynamic>{
      'tipObjektaSlikeId': instance.tipObjektaSlikeId,
      'objekatId': instance.objekatId,
      'imageData': instance.imageData,
    };
