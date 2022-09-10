part of 'objectpictures.dart';

// import 'package:firstapp/model/objectpictures.dart';

ObjectPictures _$ObjectPicturesFromJson (Map<String, dynamic> json) => ObjectPictures()
  ..tipObjektaSlikeId= json['tipObjektaSlikeId'] as int?
  ..objekatId = json['objekatId'] as int?
  ..objekat= json['objekat'] == null
          ? null
          : Objekat.fromJson(json['object'] as Map<String, dynamic>);
  
  Map<String, dynamic> _$ObjectPicturesToJson(ObjectPictures instance) => <String, dynamic>{
      'tipObjektaSlikeId': instance.tipObjektaSlikeId,
      'objekatId'        : instance.objekatId,
      'objekat'          : instance.objekat
    };