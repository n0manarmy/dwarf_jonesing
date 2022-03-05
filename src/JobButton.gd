extends Button

const Job = preload("res://src/Job.gd")

var debug = true
var job: Job

func _init(_job: Job):
	if debug: print(self.name, ".set_job: ", _job.to_string())    

	self.job = _job

func _on_pressed():
	if debug: print(self.name, "._on_pressed: ", self.job)    
	return self.job
