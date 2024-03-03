import 'package:json_annotation/json_annotation.dart';

part 'rezervacija.g.dart';

@JsonSerializable()
class Rezervacija{
int? rezervacijaId;
String? datumPrijave;
String? datumOdjave;
int? brojOdraslih;
int? brojDjece;
bool otkazano;
int? objekatId;
Rezervacija(this.rezervacijaId,this.datumPrijave,this.datumOdjave, this.brojOdraslih,
this.brojDjece,this.otkazano,this.objekatId);

factory Rezervacija.fromJson(Map<String,dynamic> json)=>_$RezervacijaFromJson(json);

Map<String,dynamic> toJson()=>_$RezervacijaToJson(this);
}
