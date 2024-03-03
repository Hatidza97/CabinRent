import 'package:json_annotation/json_annotation.dart';

part 'pictures.g.dart';

@JsonSerializable()
class TipObjektaSllike{
int? tipObjektaSlikeId;
int? objekatId;
String? imageData;
TipObjektaSllike(this.tipObjektaSlikeId,this.objekatId,this.imageData);

factory TipObjektaSllike.fromJson(Map<String,dynamic> json)=>_$TipObjektaSllikeFromJson(json);

Map<String,dynamic> toJson()=>_$TipObjektaSllikeToJson(this);
}