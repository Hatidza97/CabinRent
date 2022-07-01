 
import 'package:flutter/cupertino.dart';

import '../../widgets/master_screen.dart';

class ObjectDetailsScreen extends StatefulWidget {
  static const String routeName = "/object_details";
  String id;
  ObjectDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<ObjectDetailsScreen> createState() => _ObjectDetailsScreenState();
}

class _ObjectDetailsScreenState extends State<ObjectDetailsScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Center(child: Text(this.widget.id),),
    );
  }
} 