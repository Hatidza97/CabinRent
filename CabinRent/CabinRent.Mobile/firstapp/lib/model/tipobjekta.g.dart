
part of 'tipobjekta.dart';

TipObjekta _$TipObjektaFromJson (Map<String, dynamic> json) => TipObjekta()
  ..tipObjektaId= json['tipObjektaId'] as int?
  ..tip = json['tip'] as String?;
  
  Map<String, dynamic> _$TipObjektaToJson(TipObjekta instance) => <String, dynamic>{
      'tipObjektaId': instance.tipObjektaId,
      'tip': instance.tip
    };