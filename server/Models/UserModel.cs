namespace Project2.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
      
    }
}



 < div className = "col-md-2 mr-3" >
      < h3 > Choose Fight </ h3 >
      < Radio.Group value ={ selectedOption}
onChange ={ handleOptionChange}>
        < Space direction = "vertical" >
          < Radio value ={ 1}> Weapon Base </ Radio >
          < Radio value ={ 2}> Skill Base </ Radio >
          < Radio value ={ 3}> Fight All Characters</Radio>
        </Space>
      </Radio.Group>
      {selectedOption === 2 && ( // Show the Select component only when "Skill Base" is selected (value 2)
        <>
          <h3>Add Skill</h3>
          <Select
            bordered ={false}
            placeholder = "Select a Skill for Character"
            size = "large"
            showSearch
            className = "form-select mb-3 mt-3 border border-dark w-75"
            value={selectedSkillId}
            onChange ={ (value) => setSelectedSkillId(value)}
          >
            {
    skills.map((c, index) => (
              < Option key ={ c.id}
    value ={ c.id}>
                { c.name}
              </ Option >
            ))}
          </ Select >
        </>
      )}
      < button onClick ={ handleSkill}> submit </ button >
    </ div >
  );




