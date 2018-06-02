package com.project.service;

import java.util.ArrayList;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.project.domain.Ucionica;
import com.project.repository.ClassroomRepository;

@Service
public class ClassroomServiceImpl implements ClassroomService {

	@Autowired
	private ClassroomRepository classroomRepository;

	@Override
	public Ucionica save(Ucionica u) {
		Ucionica classroom = classroomRepository.findByLabel(u);
		if(classroom != null){
			return null;
		}
		return classroomRepository.save(u);
	}
	
	@Override
	public boolean delete(Ucionica u) {
		classroomRepository.delete(u);
		return true;
	}
	@Override
	public ArrayList<Ucionica> get() {
		return (ArrayList<Ucionica>) classroomRepository.findAll();
		
	}
	
	@Override
	public Ucionica change(Ucionica u) {
		
		Ucionica classroom = classroomRepository.findByLabel(u);
		classroom.setDescription(u.getDescription());
		classroom.setLabel(u.getLabel());
		classroom.setOs(u.getOs());
		classroom.setProjector(u.isProjector());
		classroom.setSlots(u.getSlots());
		classroom.setSmartTable(u.isSmartTable());
		classroom.setTableExists(u.isTableExists());
		
		return classroomRepository.save(classroom);
	}
	
	
}
