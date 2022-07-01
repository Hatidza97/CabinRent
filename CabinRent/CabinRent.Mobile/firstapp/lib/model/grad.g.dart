part of 'grad.dart';
Grad _$GradFromJson(Map<String, dynamic> json) => Grad()
  ..gradId = json['objekatId'] as int?
  ..naziv = json['naziv'] as String?
  ..postBroj=json['postBroj'] as String?;

Map<String, dynamic> _$GradToJson(Grad instance) => <String, dynamic>{
      'gradId': instance.gradId,
      'naziv': instance.naziv,
      'postBroj': instance.postBroj
    };
