import 'package:json_annotation/json_annotation.dart';
part 'client.g.dart';

@JsonSerializable()
class Klijent {
  int? klijentId;
  String? ime;
  String? prezime;
  String? korisnickoIme;
  String? telefon;
  String? slika;

  Klijent(){}
  factory Klijent.fromJson(Map<String,dynamic>json)=>_$KlijentFromJson(json);
  Map<String,dynamic> toJson()=>_$KlijentToJson(this);

}