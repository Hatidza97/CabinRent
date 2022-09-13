 
// import 'package:flutter/cupertino.dart';
// import 'package:flutter/material.dart';

// import '../../widgets/master_screen.dart';

// class ObjectDetailsScreen extends StatefulWidget {
//   static const String routeName = "/object_details";
//   // String id;
//   ObjectDetailsScreen({Key? key}) : super(key: key);

//   @override
//   State<ObjectDetailsScreen> createState() => _ObjectDetailsScreenState();
// }

// class _ObjectDetailsScreenState extends State<ObjectDetailsScreen> {
//   @override
//   Widget build(BuildContext context) {
//   final Map arguments = ModalRoute.of(context)!.settings.arguments as Map;
//   print(arguments["id"]);
//   print(arguments);
//     return Scaffold(
//        appBar: AppBar(
//         title: Text("Detalji objekta"),
//       ),
//       body: SingleChildScrollView(
//         child:Column(children: [Container(child: Text(arguments["naziv"]),),
//         Container(
//           child: Text(arguments["brojmjestadjeca"].toString()),
//         ),
//          Container(
//           child: Text(arguments["brojmjestaOdrasli"].toString()),
//          )
//         ,
//         //  Container(
//         //   child: Text(arguments["tipobjekta"].toString()),
//         // ),
//         ],
//         )
//         ),
//     );
    
//   }
// } 
import 'package:firstapp/providers/objectpictures_provider.dart';
import 'package:firstapp/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../model/object.dart';
import '../../model/objectpictures.dart';
import '../../providers/object_provider.dart';
import '../../widgets/master_screen.dart';

class ObjectDetailsScreen extends StatefulWidget {
  static const String routeName = "/object_details";
  ObjectDetailsScreen({Key? key}) : super(key: key);

  @override
  State<ObjectDetailsScreen> createState() => _ObjectDetailsScreenState();
}

class _ObjectDetailsScreenState extends State<ObjectDetailsScreen> {
  ObjectProvider? _objectProvider = null;
  ObjectPicturesProvider? _objectPicturesProvider=null;
  Objekat? data = null;
  ObjectPictures? data1=null;
  @override
  void initState() {
    super.initState();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      final arguments = ModalRoute.of(context)!.settings.arguments as Map;

      final id = arguments["id"];
      _objectProvider = context.read<ObjectProvider>();
      _objectPicturesProvider=context.read<ObjectPicturesProvider>();
      loadData(id);
      loadDataPictures();
    });
  }
  Future loadData(id) async {
    var tempData = await _objectProvider?.getById(id);
    setState(() {
      data = tempData!;
    });
  }
  Future loadDataPictures() async{
    var temp=await _objectPicturesProvider?.get();
    setState(() {
      data1=temp as ObjectPictures?;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Detalji objekta"),
      ),
      body: SingleChildScrollView(
          child: Column(
        children: [
          Container(
            height: 20,
            child: Text(data?.naziv ??""),
          ),
           Container(
            height: 20,
            color: Color.fromARGB(0, 25, 52, 120),
            child:Text(data?.opis??""),
           
           ),
          // Container(
          //   child: imageFromBase64String(data1!.imageData!)
          // )
        ],
      )),
    );
  }
}
