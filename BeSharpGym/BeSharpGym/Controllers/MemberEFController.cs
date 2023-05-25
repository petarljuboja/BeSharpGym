using BeSharpGym.Data;
using BeSharpGym.Dto;
using BeSharpGym.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeSharpGym.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberEFController : ControllerBase
{
    DataContextEF _entityFramework;

    public MemberEFController (IConfiguration config)
    {
        _entityFramework = new DataContextEF(config);
    }

   [HttpGet("GetMembers")]

   public IEnumerable<Member> GetMembers()
   {
        

        IEnumerable<Member> members = _entityFramework.Members.ToList<Member>();
        return members;
   }

     [HttpGet("GetSingleMember/{MemberId}")]
     public Member GetSingleUser(int MemberId)
     {
        Member? member = _entityFramework.Members
                        .Where(m => m.MemberId == MemberId)
                        .FirstOrDefault<Member>();
        if (member != null)
        {
        return member;
        }
        throw new Exception("Failed to get Member");
     }

     [HttpPut("EditMember")]
     public IActionResult EditMember(Member member)
     {
        
        Member? memberDb = _entityFramework.Members
                        .Where(m => m.MemberId == member.MemberId)
                        .FirstOrDefault<Member>();
        if (memberDb != null)
        {
            memberDb.FullName = member.FullName;
            memberDb.Email = member.Email;
            memberDb.RegistrationDate = member.RegistrationDate;
            memberDb.LastLoginDate = member.LastLoginDate;
            memberDb.IsPremiumMember = member.IsPremiumMember;
            memberDb.MembershipStatus = member.MembershipStatus;
        
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
        throw new Exception("Failed to Update Member");
        }
         throw new Exception("Failed to Get User");   
     }


     [HttpPost("AddMember")]
     public IActionResult AddMember(MemberDto member)
     {
        Member memberDb = new Member();

        memberDb.FullName = member.FullName;
        memberDb.Email = member.Email;
        memberDb.RegistrationDate = member.RegistrationDate;
        memberDb.LastLoginDate = member.LastLoginDate;
        memberDb.IsPremiumMember = member.IsPremiumMember;
        memberDb.MembershipStatus = member.MembershipStatus;
        _entityFramework.Add(memberDb);

        if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
        throw new Exception("Failed to Add Member");    
        }

     [HttpDelete("DeleteUser/{MemberId}")]
    public IActionResult DeleteMember(int MemberId)
     {
         Member? memberDb = _entityFramework.Members
                        .Where(m => m.MemberId == MemberId)
                        .FirstOrDefault<Member>();
        if (memberDb != null)
        {
            _entityFramework.Members.Remove(memberDb);
        
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
        throw new Exception("Failed to Delete Member");
        }
         throw new Exception("Failed to Get User");
     }
   

     }

