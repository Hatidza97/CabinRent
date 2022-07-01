import 'package:firstapp/screens/objects/object_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import 'package:provider/provider.dart';
import 'package:firstapp/providers/object_provider.dart';
class cabinrent extends StatelessWidget{
  cabinrent({Key?key}):super(key: key);
  ObjectProvider? _productProvider;
  @override
  Widget build(BuildContext context){
    _productProvider=context.watch<ObjectProvider>();
    print("called build drawer");
    return Drawer(
      child: ListView(
        children: [
          ListTile(
            title: Text('Home'),
            onTap: (){
              Navigator.popAndPushNamed(context, ObjectListScreen.routeName);
            },
          ),
        ],
      ),
    );
  }
} 