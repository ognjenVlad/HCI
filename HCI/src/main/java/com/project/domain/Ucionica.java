package com.project.domain;

import java.io.Serializable;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;

@Entity
public class Ucionica implements Serializable {

	@Id
	@GeneratedValue(strategy = GenerationType.AUTO)
	private Long id;
	
	@Column(nullable = false)
	private String label;
	
	@Column(nullable = false)
	private String description;
	
	@Column(nullable = false)
	private int slots;
	
	@Column(nullable = false)
	private boolean tableExists;
	
	@Column(nullable = false)
	private boolean projector;
	
	@Column(nullable = false)
	private boolean smartTable;
	

	@Column(nullable = false)
	private String os;
	
	//@ManyToOne(cascade = CascadeType.ALL,optional = false)
	//private Software software;

	public Ucionica() {
		super();
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getLabel() {
		return label;
	}

	public void setLabel(String label) {
		this.label = label;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public int getSlots() {
		return slots;
	}

	public void setSlots(int slots) {
		this.slots = slots;
	}

	public boolean isTableExists() {
		return tableExists;
	}

	public void setTableExists(boolean table) {
		this.tableExists = table;
	}

	public boolean isProjector() {
		return projector;
	}

	public void setProjector(boolean projector) {
		this.projector = projector;
	}

	public boolean isSmartTable() {
		return smartTable;
	}

	public void setSmartTable(boolean smartTable) {
		this.smartTable = smartTable;
	}

	public String getOs() {
		return os;
	}

	public void setOs(String os) {
		this.os = os;
	}

//	public Software getSoftware() {
//		return software;
//	}
//
//	public void setSoftware(Software software) {
//		this.software = software;
//	}
	
	
}
