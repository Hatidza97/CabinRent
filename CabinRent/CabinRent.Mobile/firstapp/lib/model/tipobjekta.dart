import 'package:json_annotation/json_annotation.dart';
part 'tipobjekta.g.dart';
@JsonSerializable()
class TipObjekta{
  int? tipObjektaId;
  String? tip;
  TipObjekta(){}
    factory TipObjekta.fromJson(Map<String,dynamic>json)=>_$TipObjektaFromJson(json);
  Map<String,dynamic> toJson()=>_$TipObjektaToJson(this);
  }
