import 'package:json_annotation/json_annotation.dart';

part 'klijent.g.dart';

@JsonSerializable()
class Klijent{
int? klijentId;
String? ime;
String? prezime;
String? email;
String? telefon;
String? korisnickoIme;
String? slika;
int? gradId;
Klijent(this.klijentId,this.ime,this.prezime,this.email,this.telefon,this.korisnickoIme,this.slika,this.gradId);

factory Klijent.fromJson(Map<String,dynamic> json)=>_$KlijentFromJson(json);

Map<String,dynamic> toJson()=>_$KlijentToJson(this);
}
