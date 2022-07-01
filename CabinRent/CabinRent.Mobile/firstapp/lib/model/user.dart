import 'dart:ffi';
import 'package:json_annotation/json_annotation.dart';
part 'user.g.dart';
@JsonSerializable()
class User{
  int? korisnikId;
  String? ime;
  String? prezime;
  String? email;
  String? telefon;
  String? korisnickoIme;
  String? slika;

  User(){}
    factory User.fromJson(Map<String,dynamic>json)=>_$UserFromJson(json);
  Map<String,dynamic> toJson()=>_$UserToJson(this);
  }
