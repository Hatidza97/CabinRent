import 'dart:ffi';
import 'package:firstapp/model/tipobjekta.dart';
import 'package:json_annotation/json_annotation.dart';
import 'user.dart';
import 'grad.dart';
import 'tipobjekta.dart';
part 'object.g.dart';

@JsonSerializable()
class Objekat {
  int? objekatId;
  String? naziv;
  String? povrsina;
  String? opis;
  int? brojMjestaDjeca;
  int? brojMjestaOdrasli;
  bool? rezervisan;
  int? korisnikId;
  User? korisnik;
  int? gradId;
  Grad? grad;
  int? tipObjektaId;
  TipObjekta? tipObjekta;
  Objekat(){}
  factory Objekat.fromJson(Map<String,dynamic>json)=>_$ObjekatFromJson(json);
  Map<String,dynamic> toJson()=>_$ObjekatToJson(this);

}