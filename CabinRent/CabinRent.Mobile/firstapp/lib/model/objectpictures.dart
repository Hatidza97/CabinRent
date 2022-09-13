import 'dart:convert';
import 'dart:typed_data';

import 'package:firstapp/model/object.dart';
import 'package:firstapp/model/tipobjekta.dart';
import 'package:json_annotation/json_annotation.dart';
part  'objectpictures.g.dart';
@JsonSerializable()
class ObjectPictures{
  int? tipObjektaSlikeId;
  int? objekatId;
  String? imageData;
  Object? objekat;
  ObjectPictures(){}
  factory ObjectPictures.fromJson(Map<String,dynamic>json)=> _$ObjectPicturesFromJson(json);
  Map<String,dynamic> toJson()=>_$ObjectPicturesToJson(this);

}