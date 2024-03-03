import 'dart:ffi';

import 'package:cabinrent_admin/models/korisnik.dart';
import 'package:cabinrent_admin/providers/grad_provider.dart';
import 'package:cabinrent_admin/providers/klijent_provider.dart';
import 'package:cabinrent_admin/providers/korisnik_provider.dart';
import 'package:cabinrent_admin/providers/pictures_provider.dart';
import 'package:cabinrent_admin/providers/product_provider.dart';
import 'package:cabinrent_admin/providers/rezervacija_provider.dart';
import 'package:cabinrent_admin/providers/tip_objekta_provider.dart';
import 'package:cabinrent_admin/screens/product_list_screen.dart';
import 'package:cabinrent_admin/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(MultiProvider(
    providers: [ChangeNotifierProvider(create: (_) => ProductProvider()),
            ChangeNotifierProvider(create: (_) => PicturesProvider()),
             ChangeNotifierProvider(create: (_) => GradProvider()),
             ChangeNotifierProvider(create: (_) => RezervacijaProvider()),
             ChangeNotifierProvider(create: (_) => TipObjektaProvider()),
             ChangeNotifierProvider(create: (_) => KlijentProvider()),
             ChangeNotifierProvider(create: (_) => KorisnikProvider())
    ],

    child: const MyMaterialApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        // This is the theme of your application.
        //
        // Try running your application with "flutter run". You'll see the
        // application has a blue toolbar. Then, without quitting the app, try
        // changing the primarySwatch below to Colors.green and then invoke
        // "hot reload" (press "r" in the console where you ran "flutter run",
        // or simply save your changes to "hot reload" in a Flutter IDE).
        // Notice that the counter didn't reset back to zero; the application
        // is not restarted.
        primarySwatch: Colors.blue,
      ),
      // home: const Text("Hello",style: TextStyle(color: Colors.blue,backgroundColor: Colors.amber),),
      home: MyMaterialApp(),
    );
  }
}

class MyAppBar extends StatelessWidget {
  String title;
  MyAppBar({Key? key, required this.title}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Text(title);
  }
}

class Counter extends StatefulWidget {
  const Counter({Key? key}) : super(key: key);

  @override
  State<Counter> createState() => _CounterState();
}

class _CounterState extends State<Counter> {
  int _count = 0;

  void _incrementCounter() {
    setState(() {
      _count++;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text("You have pushed button $_count times."),
        ElevatedButton(
          onPressed: _incrementCounter,
          child: Text('Increment++'),
        )
      ],
    );
  }
}

class LayoutExamples extends StatelessWidget {
  const LayoutExamples({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          height: 150,
          color: Colors.red,
          child: Center(
              child: Container(
            height: 100,
            color: Colors.blue,
            child: Text('Example text'),
            alignment: Alignment.center,
          )),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: [
            Text('Item 1'),
            Text('Item 2'),
            Text('Item 3'),
          ],
        ),
        Container(
          height: 150,
          color: Colors.red,
          child: Text('Container 2'),
          alignment: Alignment.center,
        )
      ],
    );
  }
}

class MyMaterialApp extends StatelessWidget {
  const MyMaterialApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        title: 'RS II MaterialApp',
        theme: ThemeData(primarySwatch: Colors.blue),
        home: LoginPage()
        // Scaffold(
        //   appBar: AppBar(
        //     title: Text('RS II desktop app'),
        //     ),
        //     body: Center(
        //       child: Column(
        //         mainAxisAlignment: MainAxisAlignment.center,
        //         children: [
        //           TextField(
        //             decoration: InputDecoration(
        //               labelText: 'Enter your name'
        //             ),
        //           ),
        //           SizedBox(
        //             height: 20,
        //           ),
        //           ElevatedButton(onPressed: (){
        //             print('Button clicked');
        //           }, child: Text('Submit'))
        //         ],
        //       )
        //     ),
        //     floatingActionButton: FloatingActionButton(onPressed: (){

        //     },
        //     child: Icon(Icons.add),),
        // ),
        );
  }
}

class LoginPage extends StatelessWidget {
  LoginPage({Key? key}) : super(key: key);

  TextEditingController _usernameController = new TextEditingController();
  TextEditingController _passwwordController = new TextEditingController();
  late ProductProvider _productProvider;
  late PicturesProvider _picturesProvider;
  late KorisnikProvider _userProvider;
  @override
  Widget build(BuildContext context) {
    _productProvider = context.read<ProductProvider>();
    _picturesProvider = context.read<PicturesProvider>();
    _userProvider=context.read<KorisnikProvider>();
    return Scaffold(
      appBar: AppBar(
        title: Text('Login'),
      ),
      body: Center(
        child: Container(
          constraints: BoxConstraints(maxWidth: 400, maxHeight: 400),
          child: Card(
              child: Padding(
            padding: const EdgeInsets.all(16.0),
            child: Column(
              children: [
                // Image.network("https://www.fit.ba/content/public/images/og-image.jpg",height: 100,width: 100,),
                Image.asset(
                  "assets/images/og-image.jpg",
                  height: 100,
                  width: 100,
                ),
                TextField(
                  decoration: InputDecoration(
                      labelText: 'Username', prefixIcon: Icon(Icons.mail)),
                  controller: _usernameController,
                ),
                SizedBox(
                  height: 8,
                ),
                TextField(
                  decoration: InputDecoration(
                      labelText: 'Password', prefixIcon: Icon(Icons.password)),
                  controller: _passwwordController,
                ),
                SizedBox(
                  height: 10,
                ),
                ElevatedButton(
                    onPressed: () async {
                      var username = _usernameController.text;
                      var password = _passwwordController.text;
                    // int? id = await _findCity(username);
                      print('Login proceed');

                      Authorization.username = username;
                      Authorization.password = password;
                    int? id = await _findCity(username);
                    print("KORISNIKID:$id");

                      Authorization.userId =id;
                      print("authorizationid:${Authorization.userId}");
                      try {
                        await _productProvider.get();
                        Navigator.of(context).push(MaterialPageRoute(
                            builder: (context) => const ProductListScreen()));
                      } on Exception catch (e) {
                        showDialog(
                            context: context,
                            builder: (BuildContext context) => AlertDialog(
                                  title: Text("Error"),
                                  content: Text(e.toString()),
                                  actions: [
                                    TextButton(
                                        onPressed: () => Navigator.pop(context),
                                        child: Text("ok"))
                                  ],
                                ));
                      }
                    },
                    child: Text('Login'))
              ],
            ),
          )),
        ),
      ),
    );
  }
  Future<int?> _findCity(String? username) async {
    try {
      var userResult = await _userProvider.get(filter: {'username': username});
      print(userResult);
      if (userResult.result.isNotEmpty) {
        Korisnik korisnik = userResult.result.first;
        int? gradNaziv = korisnik.korisnikId; // Access 'naziv' property

        print("grad: $gradNaziv");

      
        return gradNaziv;
      } else {
        return 0;
      }
    } catch (error) {
      print('Error getting data: $error');
      return 0;
    }
  }
}
