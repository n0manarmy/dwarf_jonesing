extends Object

var item_ref: int
var item_name: String
var item_value: int
var happiness_value: int

var debug_this = true

func _init(_item_ref, _item_name, _item_value, _happiness_value):
	self.item_ref = _item_ref
	self.item_name = _item_name
	self.item_value = _item_value
	self.happiness_value = _happiness_value

func _ready():
	if debug_this: print(self.name, "._ready")
	pass

func _to_string():
	return "item_ref: {}, item_name: {}, item_value: {}, happiness_value: {} " \
		.format([self.item_ref, self.item_name, self.item_value, self.happiness_value], "{}")
