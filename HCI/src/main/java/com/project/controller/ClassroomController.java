package com.project.controller;

import java.util.ArrayList;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.project.domain.Ucionica;
import com.project.service.ClassroomService;

@RequestMapping("classroom")
@RestController
public class ClassroomController {

	@Autowired
	ClassroomService classroomService;
	
	@RequestMapping(value = "/add",method = RequestMethod.POST,
			consumes = MediaType.APPLICATION_JSON_VALUE,
			produces = MediaType.APPLICATION_JSON_VALUE)
	public Ucionica save(@RequestBody Ucionica u){
		System.out.println(u);
		return classroomService.save(u);
	}
	
	@RequestMapping(value = "/get",method = RequestMethod.GET,
			produces = MediaType.APPLICATION_JSON_VALUE)
	public ArrayList<Ucionica> get(){
		return classroomService.get();
	}
	
	@RequestMapping(value = "/change",method = RequestMethod.POST,
			consumes = MediaType.APPLICATION_JSON_VALUE,
			produces = MediaType.APPLICATION_JSON_VALUE)
	public Ucionica change(@RequestBody Ucionica u){

		System.out.println(u);
		return classroomService.change(u);
		
	}
	
	@RequestMapping(value = "/delete",method = RequestMethod.POST,
			consumes = MediaType.APPLICATION_JSON_VALUE,
			produces = MediaType.APPLICATION_JSON_VALUE)
	public boolean delete(@RequestBody Ucionica u){

		System.out.println(u);
		return classroomService.delete(u);
		
	}
}
