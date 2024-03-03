import 'dart:convert';

import 'package:cabinrent_admin/models/korisnik.dart';
import 'package:cabinrent_admin/models/search_result.dart';
import 'package:cabinrent_admin/providers/base_provider.dart';
import 'package:cabinrent_admin/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

class KorisnikProvider extends BaseProvider<Korisnik> {
  KorisnikProvider(): super("Korisnici");

   @override
  Korisnik fromJson(data) {
    // TODO: implement fromJson
    return Korisnik.fromJson(data);
  }
}




// import 'dart:convert';
// import 'package:cabinrent_admin/models/product.dart';
// import 'package:cabinrent_admin/models/search_result.dart';
// import 'package:cabinrent_admin/utils/util.dart';
// import 'package:http/http.dart' as http;
// import 'package:flutter/material.dart';
// import 'package:http/http.dart';

// class ProductProvider with ChangeNotifier {
//   static String? _baseUrl;
//   String? _endpoint = "Objekat";
//   ProductProvider() {
//     _baseUrl = const String.fromEnvironment('baseUrl',
//         defaultValue: "https://localhost:7012/api/");
//   }
//   Future<SeearchResult<Objekat>> get({dynamic filter}) async {
//     var url = "$_baseUrl$_endpoint";
//     print("filter $filter");
//     if(filter!=null){
//       var queryString=getQueryString(filter);
//       url="$url?$queryString";
//     }
//     var uri = Uri.parse(url);
//     var headers = createHeaders();
//     var response = await http.get(uri, headers: headers);
//     if (isValidResponse(response)) {
//       var data = jsonDecode(response.body);

//       var result=new SeearchResult<Objekat>();

//       for(var item in data){
        
//         result.result.add(Objekat.fromJson(item));
//       }
//       return result;
//     } else {
//       throw new Exception("Something went wrong.");
//     }
//   }

//   bool isValidResponse(Response response) {
//     if (response.statusCode < 299) {
//       return true;
//     } else if (response.statusCode == 401) {
//       throw new Exception("Unauthorized");
//     } else {
//       throw new Exception("Something bad happen.");
//     }
//   }

//   Map<String, String> createHeaders() {
//     String username = Authorization.username ?? "";
//     String password = Authorization.password ?? "";

//     print("passedcreds:$username, $password");

//     String basicAuth =
//         "Basic ${base64Encode(utf8.encode('$username:$password'))}";

//     var headers = {
//       "Content-Type": "application/json",
//       "Authorization": basicAuth
//     };

//     return headers;
//   }

//   String getQueryString(Map params,
//       {String prefix: '&', bool inRecursion: false}) {
//     String query = '';
//     params.forEach((key, value) {
//       if (inRecursion) {
//         if (key is int) {
//           key = '[$key]';
//         } else if (value is List || value is Map) {
//           key = '.$key';
//         } else {
//           key = '.$key';
//         }
//       }
//       if (value is String || value is int || value is double || value is bool) {
//         var encoded = value;
//         if (value is String) {
//           encoded = Uri.encodeComponent(value);
//         }
//         query += '$prefix$key=$encoded';
//       } else if (value is DateTime) {
//         query += '$prefix$key=${(value as DateTime).toIso8601String()}';
//       } else if (value is List || value is Map) {
//         if (value is List) value = value.asMap();
//         value.forEach((k, v) {
//           query +=
//               getQueryString({k: v}, prefix: '$prefix$key', inRecursion: true);
//         });
//       }
//     });
//     return query;
//   }
// }
