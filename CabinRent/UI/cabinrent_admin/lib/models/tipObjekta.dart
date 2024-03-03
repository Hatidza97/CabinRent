import 'package:json_annotation/json_annotation.dart';

part 'tipObjekta.g.dart';

@JsonSerializable()
class TipObjektum{
int? tipObjektaId;
String? tip;
TipObjektum(this.tipObjektaId,this.tip);

factory TipObjektum.fromJson(Map<String,dynamic> json)=>_$TipObjektumFromJson(json);

Map<String,dynamic> toJson()=>_$TipObjektumToJson(this);
}