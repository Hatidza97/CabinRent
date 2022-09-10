import 'package:firstapp/main.dart';
import 'package:firstapp/model/objectpictures.dart';
import 'package:firstapp/providers/object_provider.dart';
import 'package:firstapp/providers/objectpictures_provider.dart';
import 'package:firstapp/screens/objects/objectpictures_screen.dart';
import 'package:firstapp/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';
import 'package:firstapp/model/object.dart';
class ObjectListScreen extends StatefulWidget {
 static const String routeName="/objects";

  const ObjectListScreen({Key? key}) : super(key: key);

  @override
  State<ObjectListScreen> createState() => _ObjectListScreenState();
}

class _ObjectListScreenState extends State<ObjectListScreen> {
  ObjectProvider? _objectProvider=null;
  List<Objekat> data=[];
  List<ObjectPictures> dataObjectPictures=[];
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _objectProvider=context.read<ObjectProvider>();
    print("Called initState");
    loadData();
  }
  
  Future loadData() async {
    var tempData= await _objectProvider?.get();
    setState(() {
      data=tempData!;
    });
  }
  @override
  Widget build(BuildContext context) {
    print("Called build $data");
    return Scaffold(
      appBar: AppBar(),
      drawer: Container(
        color: Colors.black,
        child: Column(children: [
          const SizedBox(height: 100),
          TextButton.icon(onPressed: (){}, icon: Icon(Icons.person), label: Text('Edit profile'))
        ],),
      ),
      body: SafeArea(
        child:SingleChildScrollView(
        child:Container(
          child: Column( 
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              _buildHeader(),
            
             Container(
              height: 200,
              child:  GridView(gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 1,
                childAspectRatio: 4/3,
                crossAxisSpacing: 30,
                mainAxisSpacing: 30
              ),
              scrollDirection: Axis.horizontal,
              children: _buildObjectCardList(),
              ),
             ) 
            ],
          ),
        ) ) ,)
    );
  }
  Widget _buildHeader(){
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 20,vertical: 10),
      child: Text("Objects",style: TextStyle(color: Colors.grey,fontSize: 40,fontWeight: FontWeight.bold),),
    );
  }

   List<Widget> _buildObjectCardList(){
    if(data.length==0){
      return [Text("Loading...")];
    }
    List<Widget> list= data.map((x)=>GestureDetector(onTap: (){
      // Navigator.pushNamed(context, ObjectDetailsScreen.routeName);
      //_buildObjectDetailsCardList();
    },
      child: Container(
        height: 200,
        width: 200,
        child: Column(
         
          children: [
            Container(
            child: Text(x.naziv ??""),
            ),
            Container(
              child: Text(x.povrsina??""),
            ),
            Container(
              child: Text(x.opis??""),
            ),
            Container(
              child: Text(x.brojMjestaDjeca.toString()),
            ),
            Container(
              child: Text(x.brojMjestaOdrasli.toString()),
            ),
            Container(
              child: TextButton(  
                style: TextButton.styleFrom(
                primary: Colors.blue,
                 onSurface: Colors.red,
                ),
                onPressed: () {
                   Navigator.pushNamed(context, ObjectDetailsScreen.routeName, arguments:
                    {
                      "id":x.objekatId,
                      "naziv":x.naziv,
                      "opis":x.opis,
                      "tipobjekta":x.tipObjekta,
                      "brojmjestadjeca":x.brojMjestaDjeca,
                      "brojmjestaOdrasli":x.brojMjestaOdrasli
                      });
                 },
                child: Text('Detalji objekta'),),
            )
          ],
        ),
      ),
    )).cast<Widget>().toList();

    return list;
  }
  List<Widget> _buildObjectDetailsCardList(){
    if(dataObjectPictures.length==0){
      return [Text("Loading...")];
    }
    List<Widget> list= dataObjectPictures.map((x)=>GestureDetector(onTap: (){
      Navigator.pushNamed(context, "${ObjectDetailsScreen.routeName}/${x.objekatId}");
    },
      child: Container(
        height: 200,
        width: 200,
        child: Column(
         
          children: [
            // Container(
            // child: Text(x.naziv ??""),
            // ),
            // Container(
            //   child: Text(x.povrsina??""),
            // ),
            // Container(
            //   child: Text(x.opis??""),
            // ),
            // Container(
            //   child: Text(x.brojMjestaDjeca.toString()),
            // ),
            // Container(
            //   child: Text(x.brojMjestaOdrasli.toString()),
            // ),
            Container(
              child: Text('TEST'),
            )
          ],
        ),
      ),
    )).cast<Widget>().toList();

    return list;
  }
} 