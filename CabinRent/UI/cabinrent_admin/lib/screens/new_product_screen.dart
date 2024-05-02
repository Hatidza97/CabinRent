import 'dart:convert';
import 'dart:io';

import 'package:cabinrent_admin/models/search_result.dart';
import 'package:cabinrent_admin/models/grad.dart';
import 'package:cabinrent_admin/models/product.dart';

import 'package:cabinrent_admin/models/tipObjekta.dart';
import 'package:cabinrent_admin/providers/grad_provider.dart';
import 'package:cabinrent_admin/providers/korisnik_provider.dart';
import 'package:cabinrent_admin/providers/pictures_provider.dart';
import 'package:cabinrent_admin/providers/product_provider.dart';
import 'package:cabinrent_admin/providers/tip_objekta_provider.dart';
import 'package:cabinrent_admin/screens/product_list_screen.dart';
import 'package:cabinrent_admin/utils/util.dart';
import 'package:cabinrent_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:file_picker/file_picker.dart';

class ProductInsertScreen extends StatefulWidget {
  Objekat? objekat;
  ProductInsertScreen({Key? key, this.objekat}) : super(key: key);

  @override
  State<ProductInsertScreen> createState() => _ProductInsertScreenState();
}

class _ProductInsertScreenState extends State<ProductInsertScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  late PicturesProvider _picturesProvider;
  late GradProvider _cityProvider;
  late KorisnikProvider _userProvider;
  late TipObjektaProvider _objectTypeProvider;
  late ProductProvider _productProvider;
  Map<String, dynamic> _initialValue = {};

  SeearchResult<Grad>? gradResult;
  SeearchResult<TipObjektum>? tipObjektaResult;
  bool isLoading = true;

  File? _image;
  String? _base64Image;

  @override
  void initState() {
    super.initState();

    _initialValue = {
      'naziv': widget.objekat?.naziv,
      'povrsina': widget.objekat?.povrsina,
      'brojMjestaDjeca': widget.objekat?.brojMjestaDjeca.toString(),
      'brojMjestaOdrasli': widget.objekat?.brojMjestaOdrasli.toString(),
      'brojMjestaUkupno': widget.objekat?.brojMjestaUkupno.toString(),
      'opis': widget.objekat?.opis,
      'rezervisan': false,
      'gradId': widget.objekat?.gradId.toString(),
      'cijena': widget.objekat?.cijena.toString(),
      'tipObjektaId': widget.objekat?.tipObjektaId.toString(),
      'korisnikId': Authorization.userId.toString(),
      'objekatId': widget.objekat?.objekatId.toString(),
    };
    _cityProvider = context.read<GradProvider>();
    _objectTypeProvider = context.read<TipObjektaProvider>();
    initForm();
  }

  void didChangeDependencies() {
    super.didChangeDependencies();
    _picturesProvider = context.read<PicturesProvider>();
    _cityProvider = context.read<GradProvider>();
    _productProvider = context.read<ProductProvider>();
    _objectTypeProvider = context.read<TipObjektaProvider>();
    _userProvider = context.read<KorisnikProvider>();
    if (widget.objekat != null) {
      setState(() {
        _formKey.currentState?.patchValue(_initialValue);
      });
    }
  }

  Future initForm() async {
    gradResult = await _cityProvider.get();
    print(gradResult);

    tipObjektaResult = await _objectTypeProvider.get();
    print(tipObjektaResult);

    setState(() {
      isLoading = false;
    });
  }

  List<File> _selectedImages = [];
  FormBuilder _buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
                Expanded(
                  child: FormBuilderTextField(
                    decoration: InputDecoration(labelText: "Naziv"),
                    name: "naziv",
                  ),
                ),
                const SizedBox(
                  width: 10,
                ),
                Expanded(
                  child: FormBuilderTextField(
                    decoration: InputDecoration(labelText: "Površina"),
                    name: "povrsina",
                  ),
                ),
              ],
            ),
          ),
          Padding(
            padding: EdgeInsets.all(10),
            child: Row(
              children: [
                Expanded(
                  child: FormBuilderTextField(
                    name: "brojMjestaDjeca",
                    decoration:
                        InputDecoration(labelText: "Broj mjesta (djeca)"),
                  ),
                ),
                SizedBox(
                  width: 20,
                ),
                Expanded(
                  child: FormBuilderTextField(
                    name: "brojMjestaOdrasli",
                    decoration:
                        InputDecoration(labelText: "Broj mjesta (odrasli)"),
                  ),
                ),
                SizedBox(
                  width: 20,
                ),
                Expanded(
                  child: FormBuilderTextField(
                    name: "brojMjestaUkupno",
                    decoration:
                        InputDecoration(labelText: "Broj mjesta (ukupno)"),
                  ),
                )
              ],
            ),
          ),
          Padding(
            padding: EdgeInsets.all(10),
            child: Row(children: [
              Expanded(
                child: FormBuilderTextField(
                  name: "cijena",
                  decoration: InputDecoration(labelText: "Cijena"),
                ),
              ),
              SizedBox(
                width: 20,
              ),
              Expanded(
                child: FormBuilderTextField(
                  name: "opis",
                  decoration: InputDecoration(labelText: "Opis"),
                ),
              )
            ]),
          ),
          Padding(
              padding: EdgeInsets.all(10),
              child: Row(children: [
                Expanded(
                  child: FormBuilderDropdown<String>(
                    name: 'gradId',
                    decoration: InputDecoration(
                      labelText: 'Grad',
                      suffix: IconButton(
                        icon: const Icon(Icons.close),
                        onPressed: () {
                          _formKey.currentState!.fields['gradId']?.reset();
                        },
                      ),
                      hintText: 'Odaberi grad',
                    ),
                    items: gradResult?.result
                            .map((item) => DropdownMenuItem(
                                  alignment: AlignmentDirectional.center,
                                  value: item.gradId.toString(),
                                  child: Text(item.naziv ?? ""),
                                ))
                            .toList() ??
                        [],
                  ),
                ),
                Expanded(
                  child: FormBuilderDropdown<String>(
                    name: 'tipObjektaId',
                    decoration: InputDecoration(
                      labelText: 'Tip objekta',
                      suffix: IconButton(
                        icon: const Icon(Icons.close),
                        onPressed: () {
                          _formKey.currentState!.fields['tipObjektaId']
                              ?.reset();
                        },
                      ),
                      hintText: 'Odaberi tip objekta',
                    ),
                    items: tipObjektaResult?.result
                            .map((item) => DropdownMenuItem(
                                  alignment: AlignmentDirectional.center,
                                  value: item.tipObjektaId.toString(),
                                  child: Text(item.tip ?? ""),
                                ))
                            .toList() ??
                        [],
                  ),
                ),
              ])),
          Padding(
            padding: EdgeInsets.all(10),
            child: Row(
              children: [
                Expanded(
                  child: FormBuilderCheckbox(
                    name: 'rezervisan',
                    title: Text("Rezervisan"),
                    initialValue: false,
                  ),
                ),
                Expanded(
                  child: FormBuilderTextField(
                    name: "korisnikId",
                    decoration: InputDecoration(labelText: "Korisnik"),
                    enabled: false,
                  ),
                )
              ],
            ),
          ),
          Padding(
            padding: EdgeInsets.all(10),
            child: Row(children: [
              Expanded(
                  child: FormBuilderField(
                name: 'imageData',
                builder: ((field) {
                  return InputDecorator(
                    decoration: InputDecoration(
                      label: Text('Odaberite sliku'),
                      errorText: field.errorText,
                    ),
                    child: ListTile(
                      leading: Icon(Icons.photo),
                      title: Text("Select image"),
                      trailing: Icon(Icons.file_upload),
                      onTap: getImage,
                    ),
                  );
                }),
                initialValue:
                    _base64Image ?? null, // Check if _base64Image is not null
              )),
            ]),
          ),
          ElevatedButton(
            onPressed: _saveData,
            child: Text("Sacuvaj"),
          ),
        ],
      ),
    );
  }

Future<void> _saveData() async {
  // Save the data from the form
  _formKey.currentState?.saveAndValidate();
  var request = Map<String, dynamic>.from(_formKey.currentState!.value);

  try {
    // Insert the data into the database
    var response = await _productProvider.insert(request);

    // Show a success message using a dialog
    showDialog(
      context: context,
      builder: (BuildContext context) => AlertDialog(
        title: Text("Success"),
        content: Text("Vaše izmjene su uspješno sačuvane!"),
        actions: [
          TextButton(
            onPressed: () {
              Navigator.pop(context); // Close the dialog
              Navigator.of(context).pushReplacement(
                MaterialPageRoute(
                  builder: (context) => const ProductListScreen(), // Redirect to ProductListScreen
                ),
              );
            },
            child: Text("OK"),
          ),
        ],
      ),
    );
  } catch (e) {
    // Show an error message using a dialog
    showDialog(
      context: context,
      builder: (BuildContext context) => AlertDialog(
        title: Text("Error"),
        content: Text(e.toString()),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: Text("OK"),
          ),
        ],
      ),
    );
  }
}


  Future getImage() async {
    var result = await FilePicker.platform.pickFiles(type: FileType.image);

    if (result != null) {
      if (result.files.isNotEmpty) {
        print("File path: ${result.files.single.path}");
        _image = File(result.files.single.path!);

        // Read the bytes of the image file
        List<int> imageBytes = await _image!.readAsBytes();

        // Convert the bytes to base64
        _base64Image = base64Encode(imageBytes);

        // Update the form's imageData field with the base64 image data
        _formKey.currentState?.fields['imageData']?.didChange(_base64Image);

        // Call _saveData here
        await _saveData();
      } else {
        print("No files selected");
      }
    } else {
      print("File picking canceled");
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: 'Dodaj novi objekat',
      child: _buildForm(),
    );
  }
}
