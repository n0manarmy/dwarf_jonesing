extends Node2D

onready var signals_manager = get_node_or_null("/root/SignalsManager")

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")
	signals_manager.connect("remove_board_overlay", self, "remove_board_overlay")

func remove_board_overlay():
	if debug_this: print(self.name + ".remove_board_overlay")
	queue_free()


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
