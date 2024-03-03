import 'dart:convert';

import 'package:cabinrent_admin/models/search_result.dart';
import 'package:cabinrent_admin/models/tipObjekta.dart';
import 'package:cabinrent_admin/providers/base_provider.dart';
import 'package:cabinrent_admin/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

class TipObjektaProvider extends BaseProvider<TipObjektum> {
  TipObjektaProvider(): super("TipObjektum");

   @override
  TipObjektum fromJson(data) {
    // TODO: implement fromJson
    return TipObjektum.fromJson(data);
  }
}
