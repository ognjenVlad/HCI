package com.project.service;

import org.springframework.beans.factory.annotation.Autowired;

import com.project.domain.Departman;
import com.project.repository.DepartmanRepository;

public class DepartmanServiceImpl implements DepartmanService{

	@Autowired
	DepartmanRepository departmanRepository;
	
	@Override
	public Departman save(Departman u) {
		Departman departman = departmanRepository.findByLabel(u);
		if(departman != null){
			return null;
		}
		return departmanRepository.save(u);
	
	}

	@Override
	public boolean delete(Departman u) {
		departmanRepository.delete(u);
		return true;
	}

	@Override
	public Departman change(Departman u) {
		Departman d = departmanRepository.findByLabel(u);
		d.setDate(u.getDate());
		d.setDescription(u.getDescription());
		d.setLabel(u.getLabel());
		d.setName(u.getName());
		return null;
	}

}
