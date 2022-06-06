extends Node

const Job = preload("res://src/Job.gd")

signal update_round_timer_value(caller)
signal update_game_rounds_value(caller)
signal remove_board_overlay(caller)
signal player_count_selected (caller)
signal update_debug_scene (caller)
signal player_position_updated(caller)
signal player_data_updated(caller)
signal player_reset(caller)
signal player_time_up(caller)
signal on_done_clicked(caller)
signal reset_players(caller)
signal increment_player(caller)
signal location_entered_stop_movement(caller)
signal goals_values_updated(caller)
signal global_data_updated(caller)
signal update_job_economy(caller)
signal setup_next_player(caller)
signal scene_change(caller, scene_name, state)
signal disable_location_buttons(caller, state)
signal goals_values_done(caller, values)
signal update_position(caller, new_pos)
signal on_rest_button_pressed(caller, values)
signal location_entered_move_player(caller, pos)
signal location_entered_present_scene(caller, scene)
signal job_manager_check_get_job(caller, job)
signal change_player_job(caller, job)
signal job_results_container_update(caller, message)
signal _on_WorkButton_pressed(caller)

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
