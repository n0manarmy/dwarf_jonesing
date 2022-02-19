extends Node

signal update_round_timer_value
# from: 
# to: 

signal update_game_rounds_value
# from: 
# to: 

signal remove_board_overlay
# from: StartValuesScene
# to: BoardCoverLayer

signal player_count_selected 
# from: PlayerCountSelectScene
# to: GlobalData

signal update_debug_scene 
# from: PlayerCountSelectScene
# to: DebugScene

signal player_position_updated
signal player_data_updated
# from: GlobalData
# to: TravelPath
signal player_turn_over
signal player_time_up

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
