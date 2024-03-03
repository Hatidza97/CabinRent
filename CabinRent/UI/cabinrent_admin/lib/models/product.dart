import 'package:json_annotation/json_annotation.dart';

part 'product.g.dart';

@JsonSerializable()
class Objekat{
int? objekatId;
String? naziv;
String? povrsina;
int? brojMjestaDjeca;
int? brojMjestaOdrasli;
int? brojMjestaUkupno;
String? opis;
bool rezervisan;
int? gradId;
int? cijena;
int? tipObjektaId;
int? korisnikId;


Objekat(this.objekatId,this.naziv,this.povrsina,this.brojMjestaDjeca,this.brojMjestaOdrasli,
this.brojMjestaUkupno,this.opis,this.rezervisan,this.gradId,this.cijena,this.tipObjektaId,this.korisnikId);

factory Objekat.fromJson(Map<String,dynamic> json)=>_$ObjekatFromJson(json);

Map<String,dynamic> toJson()=>_$ObjekatToJson(this);
}
