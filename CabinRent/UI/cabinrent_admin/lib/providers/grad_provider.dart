import 'dart:convert';

import 'package:cabinrent_admin/models/grad.dart';
import 'package:cabinrent_admin/models/search_result.dart';
import 'package:cabinrent_admin/providers/base_provider.dart';
import 'package:cabinrent_admin/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

class GradProvider extends BaseProvider<Grad> {
  GradProvider(): super("Grad");

   @override
  Grad fromJson(data) {
    // TODO: implement fromJson
    return Grad.fromJson(data);
  }
}
