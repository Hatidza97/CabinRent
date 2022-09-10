import 'package:firstapp/model/user.dart';
import 'package:firstapp/screens/objects/object_screen.dart';
import 'package:firstapp/services/APIservice.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:firstapp/utils/util.dart';


import '../../providers/user_provider.dart';

class Login extends StatefulWidget {
 static const String routeName="/login";

  const Login({Key? key}) : super(key: key);

  @override
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
  TextEditingController _usernameController = new TextEditingController();
  TextEditingController _passwordController = new TextEditingController();
  late UserProvider _userProvider;

  // Future<void> GetProfil() async {
  //   var result = await APIService.getById('Korisnici','');
  //   if(result != null) {
  //     APIService.prijavljeniKorisnik = User.fromJson(result);
  //   }
  // }

  @override
 Widget build(BuildContext context){

    _userProvider =Provider.of<UserProvider>(context, listen: false);
    return Scaffold(
      appBar: AppBar(
        title: Text("Cabin rent"),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 400,
              decoration: BoxDecoration(
                image: DecorationImage(
                  image: AssetImage("assets/images/background.webp"),
                  fit: BoxFit.fill
                )
              ),
              child: Stack(children: [
                Container(
                  child: Center(child: Text("Login",style: TextStyle(color: Colors.white,fontSize: 45,fontWeight: FontWeight.bold),)),

                )
            ]
              ),
            ),
            Padding(padding: EdgeInsets.all(40),
            child: Column(
              children: [
                Container(
                  padding: EdgeInsets.all(8),
                  decoration: BoxDecoration(
                    border: Border(bottom: BorderSide(
                      color:Colors.grey ))
                  ),
                  child: TextField(
                    controller: _usernameController,
                      decoration: InputDecoration(
                      border: InputBorder.none,
                      hintText: "Korisnicko ime"
                    ),
                  ),
                ),
                 Container(
                   padding: EdgeInsets.all(8),
                  child: TextField(
                    controller: _passwordController,
                    decoration: InputDecoration(
                      border: InputBorder.none,
                      hintText: "Lozinka"
                    ),
                  ),
                ),
                SizedBox(height: 2,),
                Container(
                  height: 50,
                  margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(10),
                    gradient: LinearGradient(colors:[ Color.fromARGB(255, 152, 129, 146),
                    Color.fromARGB(255, 204, 182, 199)])
                  ),
                  child: InkWell(
                      onTap: () async {
                  try {
                    Authorization.username = _usernameController.text;
                    Authorization.password = _passwordController.text;

                    await _userProvider.get();

                    Navigator.pushNamed(context, ObjectListScreen.routeName);
                    }
                    catch(e){
                      showDialog(
                        context: context,
                        builder: (BuildContext context) => AlertDialog(
                              title: Text("Error"),
                              content: Text(e.toString()),
                              actions: [
                                TextButton(
                                  child: Text("Ok"),
                                  onPressed: () => Navigator.pop(context),
                                )
                              ],
                            ));
                    }
                      },

                    child: Center(child: Text("Login")),
                  ),
                ),
              ]),
            )
          ],
        ),
      )
    );
  }
}