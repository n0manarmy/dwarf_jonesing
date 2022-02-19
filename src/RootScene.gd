extends Node2D

var debug_this = true

onready var signals_manager = get_node_or_null("/root/SignalsManager")

func _ready():
	print(self.name + "._ready")
	signals_manager.emit_signal("disable_location_buttons", true)
