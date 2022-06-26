# UNUSED

extends Object

export var item_name: String
export var base_cost: int

var debug_this = true

func _init(item_name, base_cost):
	self.item_name = item_name
	self.base_cost = base_cost

func _ready():
	if debug_this: print(self.name, "._ready")
	pass

func _to_string():
	return "item_name: {}, base_cast: {} " \
		.format([self.item_name, self.base_cost], "{}")
