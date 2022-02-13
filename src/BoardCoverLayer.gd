extends Node2D

onready var start_values_node = get_node_or_null("/root/RootScene/StartValuesScene")

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")
	if start_values_node != null:
		if debug_this: print(self.name + ".start_values_node != null")
		start_values_node.connect("remove_board_overlay", self, "remove_board_overlay")
		#connect("start_values_scene.remove_board_overlay", self, "remove_board_overlay")

func remove_board_overlay():
	if debug_this: print(self.name + ".remove_board_overlay")
	queue_free()


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
