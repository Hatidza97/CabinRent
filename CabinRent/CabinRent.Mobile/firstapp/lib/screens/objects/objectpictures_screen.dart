 
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../../widgets/master_screen.dart';

class ObjectDetailsScreen extends StatefulWidget {
  static const String routeName = "/object_details";
  // String id;
  ObjectDetailsScreen({Key? key}) : super(key: key);

  @override
  State<ObjectDetailsScreen> createState() => _ObjectDetailsScreenState();
}

class _ObjectDetailsScreenState extends State<ObjectDetailsScreen> {
  @override
  Widget build(BuildContext context) {
  final Map arguments = ModalRoute.of(context)!.settings.arguments as Map;
  print(arguments["id"]);
  print(arguments);
    return Scaffold(
       appBar: AppBar(
        title: Text("Detalji objekta"),
      ),
      body: SingleChildScrollView(
        child:Column(children: [Container(child: Text(arguments["naziv"]),),
        Container(
          child: Text(arguments["brojmjestadjeca"].toString()),
        ),
         Container(
          child: Text(arguments["brojmjestaOdrasli"].toString()),
         )
        ,
        //  Container(
        //   child: Text(arguments["tipobjekta"].toString()),
        // ),
        ],
        )
        ),
    );
    
  }
} 