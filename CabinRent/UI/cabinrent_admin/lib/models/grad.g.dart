// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'grad.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Grad _$GradFromJson(Map<String, dynamic> json) {
  return Grad(
    json['gradId'] as int,
    json['naziv'] as String,
    json['postBroj'] as String,
  );
}

Map<String, dynamic> _$GradToJson(Grad instance) => <String, dynamic>{
      'gradId': instance.gradId,
      'naziv': instance.naziv,
      'postBroj': instance.postBroj,
    };
