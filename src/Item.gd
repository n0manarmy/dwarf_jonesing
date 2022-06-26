extends Object

var item_ref: int
var item_name: String
var item_value: int
var happiness_value: int

var debug_this = true

func _init(item_ref, item_name, item_value, happiness_value):
	self.item_ref = item_ref
	self.item_name = item_name
	self.item_value = item_value
	self.happiness_value = happiness_value

func _ready():
	if debug_this: print(self.name, "._ready")
	pass

func _to_string():
	return "item_ref: {}, item_name: {}, item_value: {}, happiness_value: {} " \
		.format([self.item_ref, self.item_name, self.item_value, self.happiness_value], "{}")
