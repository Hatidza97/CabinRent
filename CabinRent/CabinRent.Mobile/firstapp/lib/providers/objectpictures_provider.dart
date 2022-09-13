
import '../model/objectpictures.dart';
import 'base_provider.dart';

class ObjectPicturesProvider extends BaseProvider<ObjectPictures> {
 ObjectPicturesProvider() : super("TipObjektaSllike");

  @override
  ObjectPictures fromJson(data) {
    return ObjectPictures.fromJson(data);
  }
} 