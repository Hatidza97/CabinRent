import 'dart:convert';

import 'package:cabinrent_admin/models/rezervacija.dart';
import 'package:cabinrent_admin/models/search_result.dart';
import 'package:cabinrent_admin/providers/base_provider.dart';
import 'package:cabinrent_admin/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

class RezervacijaProvider extends BaseProvider<Rezervacija> {
  RezervacijaProvider(): super("Rezervacija");

   @override
  Rezervacija fromJson(data) {
    // TODO: implement fromJson
    return Rezervacija.fromJson(data);
  }
}
