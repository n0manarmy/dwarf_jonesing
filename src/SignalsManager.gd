extends Node

signal update_round_timer_value
signal update_game_rounds_value
signal remove_board_overlay
signal player_count_selected 
signal update_debug_scene 
signal player_position_updated
signal player_data_updated
signal player_time_up
signal on_done_clicked
signal reset_players
signal increment_players
signal location_entered_stop_movement
signal goals_values_updated
signal global_data_updated

signal disable_location_buttons(state)
signal goals_values_done(values)
signal update_position(new_pos)
signal on_rest_button_pressed(values)
signal location_entered_move_player(pos)
signal location_entered_present_scene(scene)


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
