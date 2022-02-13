extends Node2D

var debug_this = true

signal startup_disable_location_buttons

func _ready():
	print(self.name + "._ready")
	emit_signal("startup_disable_location_buttons")
