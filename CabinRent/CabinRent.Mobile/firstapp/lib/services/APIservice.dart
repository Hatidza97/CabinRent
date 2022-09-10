import 'dart:convert';
import 'package:http/http.dart' as http;
import 'dart:io';

import '../model/user.dart';

class APIService{
  static String? username;
  static String? password;
  static User? prijavljeniKorisnik;

  // static String apiAddress = "172.19.144.1";
  // static int apiPort = 5001;
   static String apiBase = "https://10.0.2.2:7012/api/";

  String route;

  APIService({required this.route});

  void SetParameter(String Username, String Password){
    username=Username;
    password=Password;
  }


  static Future<Iterable?> getAll(String route, dynamic object, [String? endpoint = null]) async{
    String queryString = Uri(queryParameters: object).query;
    String baseUrl=apiBase+route;
    if(endpoint != null){
      baseUrl += '/$endpoint';
    }
    if(object!=null){
      baseUrl = '$baseUrl?$queryString';
    }
    final String basicAuth='Basic ${base64Encode(utf8.encode('$username:$password'))}';
    final response= await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader:basicAuth},
    );
    if(response.statusCode==200){
      return json.decode(response.body);
    }
    return null;
  }

  //  static Future<dynamic> getById(String route, dynamic id) async{
  //    String baseUrl='$apiBase$route/$id';
  //    final String basicAuth='Basic ${base64Encode(utf8.encode('$username:$password'))}';
  //    final response= await http.get(
  //      Uri.parse(baseUrl),
  //      headers: {HttpHeaders.authorizationHeader:basicAuth},
  //    );
  //   print("done $response");
  //    if(response.statusCode==200) {
  //      return json.decode(response.body);
  //    }
  //    return null;
  //  }
   static Future<dynamic> getById(String route, dynamic id) async{
     String baseUrl='$apiBase$route/$id';
     final String basicAuth='Basic ${base64Encode(utf8.encode('$username:$password'))}';
     final response= await http.get(
       Uri.parse(baseUrl),
       headers: {HttpHeaders.authorizationHeader:basicAuth},
     );
    print("done $response");
     if(response.statusCode==200) {
       return json.decode(response.body);
     }
     return null;
   }

   static Future<dynamic> post(String route, String body) async {
     String baseUrl='$apiBase$route';
     final String basicAuth='Basic ${base64Encode(utf8.encode('$username:$password'))}';

     final response = await http.post(
       Uri.parse(baseUrl),
       headers: <String, String>{
         'Content-Type': 'application/json; charset=UTF-8',
         HttpHeaders.authorizationHeader:basicAuth
       },
       body: body,
     );

     if (response.statusCode == 201 || response.statusCode == 200) {
       return json.decode(response.body);
     }
     return null;
   }
}
