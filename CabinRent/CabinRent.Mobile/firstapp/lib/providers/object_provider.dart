import 'dart:core';
import 'package:firstapp/providers/base_provider.dart';
import 'package:firstapp/model/object.dart';
class ObjectProvider extends BaseProvider<Objekat> {
 ObjectProvider() : super("Objekat");

  @override
  Objekat fromJson(data) {
    return Objekat.fromJson(data);
  }
} 
/*class ObjectProvider with ChangeNotifier{
 HttpClient client=new HttpClient();
 IOClient? http;

  ObjectProvider(){
    print("Caled ObjectProvider");
    client.badCertificateCallback=((cert, host, port) => true);
    http=IOClient(client);
  }
  Future<List<Object>> get(dynamic searchObject) async {
  var url=Uri.parse("https://10.0.2.2:7012/api/Objekat");
  
  String username="hatidza1";
  String password="hatidza1";

  String basicAuth= "Basic ${base64Encode(utf8.encode('$username:$password'))}";
  var headers={
    "Content-Type":"application/json",
    "Authorization":basicAuth
  };
  var response = await http!.get(url,headers:headers);
   if(response.statusCode < 400){
    List data=jsonDecode(response.body);
    List<Object> list =data.map((x) => Object.fromJson(x)).cast<Object>().toList();
    return list;
   }
   else{
    throw Exception("User not allowed!");
   } 
  }
}*/